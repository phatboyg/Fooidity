namespace Fooidity.Management.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using Features;
    using Metadata;
    using Models;

    /// <summary>
    /// Features identify code that is switched
    /// </summary>
    public class FeaturesController :
        ApiController
    {
        public IEnumerable<Feature> Get()
        {
            return new[] {new Feature {CodeFeatureId = CodeFeatureMetadata<Feature_NewScreen>.Id}};
        }

        public Feature Get(string id)
        {
            return new Feature {CodeFeatureId = new Uri(id)};
        }

        public void Post([FromBody] Feature feature)
        {
        }

        public void Put(string id, [FromBody] Feature feature)
        {
        }

        public void Delete(string id)
        {
        }
    }
}