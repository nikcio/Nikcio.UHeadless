using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Members.Commands;
using Nikcio.UHeadless.Members.Models;

namespace Nikcio.UHeadless.Basics.Members.Models {
    public class BasicMember : Member<BasicProperty> {
        public BasicMember(CreateMember createMember, IPropertyFactory<BasicProperty> propertyFactory) : base(createMember, propertyFactory) {
        }

        public int? Id => MemberItem?.Id;
    }
}
