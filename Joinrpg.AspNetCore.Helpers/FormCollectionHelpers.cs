using System;
using System.Collections.Generic;
using System.Linq;
using JoinRpg.Helpers;
using Microsoft.AspNetCore.Http;

namespace Joinrpg.AspNetCore.Helpers
{
    public static class FormCollectionHelpers
    {
        public static Dictionary<string, string> ToDictionary(this IFormCollection collection)
        {
            return collection.Keys.ToDictionary(key => key, key => collection[key].First());
        }

        public static IReadOnlyDictionary<int, string> GetDynamicValuesFromPost(this HttpRequest request, string prefix)
        {
            var post = request.Form.ToDictionary();
            return post.Keys.UnprefixNumbers(prefix)
                .ToDictionary(fieldClientId => fieldClientId,
                    fieldClientId => post[prefix + fieldClientId]);
        }
    }
}