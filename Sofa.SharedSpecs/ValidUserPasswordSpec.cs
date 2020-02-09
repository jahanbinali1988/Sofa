using System;
using System.Linq.Expressions;
using Sofa.Identity.Model;
using Sofa.SharedKernel;

namespace Sofa.SharedSpecs
{
    public class ValidUserPasswordSpec : Specification<User>
    {
        private readonly string _password;
        public ValidUserPasswordSpec(string password)
        {
            this._password = password;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return r => SHA256HashGenerator.GenerateSHA256Hash(_password) == r.PasswordHash;
        }
    }
}
