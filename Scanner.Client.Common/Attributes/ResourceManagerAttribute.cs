using System;

namespace Scanner.Client.Common.Attributes {
    public class ResourceManagerAttribute : Attribute {
        public string Name { get; set; }

        public ResourceManagerAttribute() {
            Name = "";
        }
    }
}
