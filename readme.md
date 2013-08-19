Fooidity - A continuous deployment library, enabling the separation of release from deployment.
=======

# LICENSE
Apache 2.0 - see LICENSE

# INFO

### Source

 1. Clone the source down to your machine.
   `git clone git://github.com/phatboyg/Fooidity.git`
 2. Download git, ruby and gems. Install – a tutorial is [here][gems]
 3. gem install rake albacore
 4. **Important:** Run `rake global_version` in order to generate the SolutionVersion.cs file which is otherwise missing.
    * You must have git on the path in order to do this. (Right click on `Computer` > `Advanced System Settings`, `Advanced` (tab) > `Environment Variables...` > Append the git executable's directory at the end of the PATH environment variable.
 5. Edit with Visual Studio 2012 or alternatively edit and run `rake`. `rake help` displays all possible tasks that you can run. The `package` task, is what the build server does.
 6. The default is .NET 4.0.

[gems]: http://guides.rubyonrails.org/command_line.html  "How to use ruby/gems"

#### Editing in Visual Studio

 1. Run `rake global_version` in the root folder.
 2. Set Visual Studio Tools -> Options -> Text Editor -> All Languages -> Tabs to use "Tab Size" = 4, "Indent Size" = 4, and "Insert Spaces"
 3. Double-click/open the .sln file.

#### Editing the rake script

 * Getting an overview: `rake help`
 * Getting descriptions of the tasks: `rake -P`
 * Read some articles; currently we need help with environments configuration and reducing the noise in tasks by making the files FileTask-s themselves. Some of this stuff is discussed [here][fowler-rake].

In general you should define your tasks to have the least number of dependencies to function. Paths should be placed in the props dictionary at the start of the rake file.

[fowler-rake]: http://martinfowler.com/articles/rake.html  "An article about Rake for building"

# REQUIREMENTS

To run the build, rake and .NET 4.0 are required. To open the solution, you must have Visual Studio 2012.

# CREDITS
Copyright 2007-2013 Chris Patterson, All rights reserved.

