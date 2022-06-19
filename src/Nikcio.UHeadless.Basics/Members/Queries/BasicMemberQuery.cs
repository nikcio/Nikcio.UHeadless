using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChocolate.Types;
using Nikcio.UHeadless.Basics.Members.Models;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Members.Queries;

namespace Nikcio.UHeadless.Basics.Members.Queries {
    [ExtendObjectType(typeof(Query))]
    public class BasicMemberQuery : MemberQuery<BasicMember, BasicProperty> {
    }
}
