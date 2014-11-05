COPYRIGHT = "Copyright 2013 Chris Patterson"

require File.dirname(__FILE__) + "/build_support/BuildUtils.rb"
require File.dirname(__FILE__) + "/build_support/util.rb"
include FileTest
require 'albacore'
require File.dirname(__FILE__) + "/build_support/versioning.rb"

PRODUCT = 'Fooidity'
CLR_TOOLS_VERSION = 'v4.0.30319'
OUTPUT_PATH = 'bin/Release'

props = {
  :src => File.expand_path("src"),
  :nuget => File.join(File.expand_path("src"), ".nuget", "nuget.exe"),
  :output => File.expand_path("build_output"),
  :artifacts => File.expand_path("build_artifacts"),
  :lib => File.expand_path("lib"),
  :projects => ["Fooidity"]
}

desc "Cleans, compiles, il-merges, unit tests, prepares examples, packages zip"
task :all => [:default, :package]

desc "**Default**, compiles and runs tests"
task :default => [:clean, :nuget_restore, :compile, :package]

desc "Update the common version information for the build. You can call this task without building."
assemblyinfo :global_version do |asm|
  # Assembly file config
  asm.product_name = PRODUCT
  asm.description = "An implementation switching library"
  asm.version = FORMAL_VERSION
  asm.file_version = FORMAL_VERSION
  asm.custom_attributes :AssemblyInformationalVersion => "#{BUILD_VERSION}",
	:ComVisibleAttribute => false,
	:CLSCompliantAttribute => true
  asm.copyright = COPYRIGHT
  asm.output_file = 'src/SolutionVersion.cs'
  asm.namespaces "System", "System.Reflection", "System.Runtime.InteropServices"
end

desc "Prepares the working directory for a new build"
task :clean do
	FileUtils.rm_rf props[:output]
	waitfor { !exists?(props[:output]) }

	FileUtils.rm_rf props[:artifacts]
	waitfor { !exists?(props[:artifacts]) }

	Dir.mkdir props[:output]
	Dir.mkdir props[:artifacts]
end

desc "Cleans, versions, compiles the application and generates build_output/."
task :compile => [:versioning, :global_version, :build4, :tests4, :copy4]

task :copy4 => [:build4] do
  copyOutputFiles File.join(props[:src], "Fooidity/bin/Release"), "Fooidity.{dll,pdb,xml}", File.join(props[:output], 'net-4.5')
  copyOutputFiles File.join(props[:src], "Fooidity.AutofacIntegration/bin/Release"), "Fooidity.AutofacIntegration.{dll,pdb,xml}", File.join(props[:output], 'net-4.5')
  copyOutputFiles File.join(props[:src], "Fooidity.AzureIntegration/bin/Release"), "Fooidity.AzureIntegration.{dll,pdb,xml}", File.join(props[:output], 'net-4.5')
end

desc "Only compiles the application."
msbuild :build4 do |msb|
	msb.properties :Configuration => "ReleaseBuild",
		:Platform => 'Any CPU'
	msb.use :net4
	msb.targets :Rebuild
	msb.solution = 'src/Fooidity.sln'
end

def copyOutputFiles(fromDir, filePattern, outDir)
	FileUtils.mkdir_p outDir unless exists?(outDir)
	Dir.glob(File.join(fromDir, filePattern)){|file|
		copy(file, outDir) if File.file?(file)
	}
end

desc "Runs unit tests"
nunit :tests4 => [:build4] do |nunit|
  nunit.command = File.join('src', 'packages','NUnit.Runners.2.6.3', 'tools', 'nunit-console.exe')
  nunit.parameters = "/framework=#{CLR_TOOLS_VERSION}", '/nothread', '/exclude:Integration', '/nologo', '/labels', "\"/xml=#{File.join(props[:artifacts], 'nunit-test-results-net-4.0.xml')}\""
  nunit.assemblies = FileList[File.join(props[:src], "Fooidity.Tests/bin/Release", "Fooidity.Tests.dll")]
end

task :package => [:nuget, :zip_output]

desc "ZIPs up the build results."
zip :zip_output => [:versioning] do |zip|
  zip.dirs = [props[:output]]
  zip.output_path = File.join(props[:artifacts], "Fooidity-#{NUGET_VERSION}.zip")
end

desc "restores missing packages"
msbuild :nuget_restore do |msb|
  msb.use :net4
  msb.targets :RestorePackages
  msb.solution = File.join(props[:src], "Fooidity.AutofacIntegration", "Fooidity.AutofacIntegration.csproj")
end

desc "restores missing packages"
msbuild :nuget_restore do |msb|
  msb.use :net4
  msb.targets :RestorePackages
  msb.solution = File.join(props[:src], "Fooidity.AzureIntegration", "Fooidity.AzureIntegration.csproj")
end

desc "restores missing packages"
msbuild :nuget_restore do |msb|
  msb.use :net4
  msb.targets :RestorePackages
  msb.solution = File.join(props[:src], "Fooidity.ContainerTests", "Fooidity.ContainerTests.csproj")
end

desc "restores missing packages"
msbuild :nuget_restore do |msb|
  msb.use :net4
  msb.targets :RestorePackages
  msb.solution = File.join(props[:src], "Fooidity.Tests", "Fooidity.Tests.csproj")
end

desc "Builds the nuget package"
task :nuget => [:versioning, :create_nuspec] do
  sh "#{props[:nuget]} pack #{props[:artifacts]}/Fooidity.nuspec /Symbols /OutputDirectory #{props[:artifacts]}"
  sh "#{props[:nuget]} pack #{props[:artifacts]}/Fooidity.Autofac.nuspec /Symbols /OutputDirectory #{props[:artifacts]}"
  sh "#{props[:nuget]} pack #{props[:artifacts]}/Fooidity.AzureIntegration.nuspec /Symbols /OutputDirectory #{props[:artifacts]}"
end

nuspec :create_nuspec do |nuspec|
  nuspec.id = 'Fooidity'
  nuspec.version = NUGET_VERSION
  nuspec.authors = ['Chris Patterson']
  nuspec.summary = 'An implementation switching library'
  nuspec.description = 'An implementation switching library for injecting feature toggles into classes to switch implementations at runtime'
  nuspec.title = 'Fooidity'
  nuspec.project_url = 'http://github.com/phatboyg/Fooidity'
  nuspec.language = "en-US"
  nuspec.license_url = "http://www.apache.org/licenses/LICENSE-2.0"
  nuspec.require_license_acceptance
  nuspec.output_file = File.join(props[:artifacts], 'Fooidity.nuspec')
  add_files File.join(props[:output]), 'Fooidity.{dll,pdb,xml}', nuspec
  nuspec.file(File.join(props[:src], "Fooidity\\**\\*.cs").gsub("/","\\"), "src")
end

nuspec :create_nuspec do |nuspec|
  nuspec.id = 'Fooidity.Autofac'
  nuspec.version = NUGET_VERSION
  nuspec.authors = ['Chris Patterson']
  nuspec.summary = 'Fooidity integration with Autofac'
  nuspec.description = 'Adds support for Autofac, including automatic implementation selection based on FooId state at resolution time'
  nuspec.title = 'Fooidity.Autofac'
  nuspec.project_url = 'http://github.com/phatboyg/Fooidity'
  nuspec.language = "en-US"
  nuspec.license_url = "http://www.apache.org/licenses/LICENSE-2.0"
  nuspec.require_license_acceptance
  nuspec.dependency "Fooidity", NUGET_VERSION
  nuspec.dependency "Autofac", "3.5.2"
  nuspec.output_file = File.join(props[:artifacts], 'Fooidity.Autofac.nuspec')
  add_files File.join(props[:output]), 'Fooidity.AutofacIntegration.{dll,pdb,xml}', nuspec
  nuspec.file(File.join(props[:src], "Fooidity.AutofacIntegration\\**\\*.cs").gsub("/","\\"), "src")
end

nuspec :create_nuspec do |nuspec|
  nuspec.id = 'Fooidity.AzureIntegration'
  nuspec.version = NUGET_VERSION
  nuspec.authors = ['Chris Patterson']
  nuspec.summary = 'Fooidity integration with Azure'
  nuspec.description = 'Adds support for Azure storage of feature state'
  nuspec.title = 'Fooidity.AzureIntegration'
  nuspec.project_url = 'http://github.com/phatboyg/Fooidity'
  nuspec.language = "en-US"
  nuspec.license_url = "http://www.apache.org/licenses/LICENSE-2.0"
  nuspec.require_license_acceptance
  nuspec.dependency "Fooidity", NUGET_VERSION
  nuspec.dependency "WindowsAzure.Storage", "4.3.0"
  nuspec.dependency "Microsoft.WindowsAzure.ConfigurationManager", "2.0.3"
  nuspec.output_file = File.join(props[:artifacts], 'Fooidity.AzureIntegration.nuspec')
  add_files File.join(props[:output]), 'Fooidity.AzureIntegration.{dll,pdb,xml}', nuspec
  nuspec.file(File.join(props[:src], "Fooidity.AzureIntegration\\**\\*.cs").gsub("/","\\"), "src")
end

def project_outputs(props)
	props[:projects].map{ |p| "src/#{p}/bin/#{BUILD_CONFIG}/#{p}.dll" }.
		concat( props[:projects].map{ |p| "src/#{p}/bin/#{BUILD_CONFIG}/#{p}.exe" } ).
		find_all{ |path| exists?(path) }
end

def get_commit_hash_and_date
	begin
		commit = `git log -1 --pretty=format:%H`
		git_date = `git log -1 --date=iso --pretty=format:%ad`
		commit_date = DateTime.parse( git_date ).strftime("%Y-%m-%d %H%M%S")
	rescue
		commit = "git unavailable"
	end

	[commit, commit_date]
end

def add_files stage, what_dlls, nuspec
  [['net45', 'net-4.5']].each{|fw|
    takeFrom = File.join(stage, fw[1], what_dlls)
    Dir.glob(takeFrom).each do |f|
      nuspec.file(f.gsub("/", "\\"), "lib\\#{fw[0]}")
    end
  }
end

def waitfor(&block)
	checks = 0

	until block.call || checks >10
		sleep 0.5
		checks += 1
	end

	raise 'Waitfor timeout expired. Make sure that you aren\'t running something from the build output folders, or that you have browsed to it through Explorer.' if checks > 10
end
