
using System.Text.RegularExpressions;

namespace RoutingExample.CustomeConstraints
{
    public class MonthCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            // month key
            if (!values.ContainsKey(routeKey))
            {
                return false;
            }
            else
            {
                var regex = new Regex($"^(apr|jul|oct|jan)$");
                var monthValue = Convert.ToString(values[routeKey]);

                if (regex.IsMatch(monthValue))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
