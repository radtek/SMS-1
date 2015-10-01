using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodgeIt
{
    public static class Constants
    {
        public const string BaseDir = @"C:\GitRepositories\BEF\Applications\Bec.TargetFramework\MainLine\Bec.TargetFramework.DatabaseScripts\Scripts";

        public static Dictionary<int, string> TfCons = new Dictionary<int, string>(){
            {0,"Host=localhost;User Id=postgres;Password=admin;Database=TargetFramework;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"},
            {1,"Host=bec-dev-01;User Id=postgres;Password=0277922cdd;Database=TargetFramework;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"},
            {2,"Host=sys-db-01;User Id=postgres;Password=Wzrfdza8VjM3y86WTqdX;Database=TargetFramework;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"},
            {3,"Host=uat-db-01;User Id=postgres;Password=14244095dbbc6324c35067a045fd877e;Database=TargetFramework;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"}
        };

        public static Dictionary<int, string> CoreCons = new Dictionary<int, string>(){
            {0,"Host=localhost;User Id=postgres;Password=admin;Database=TargetFrameworkCore;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"},
            {1,"Host=bec-dev-01;User Id=postgres;Password=0277922cdd;Database=TargetFrameworkCore;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"},
            {2,"Host=sys-db-01;User Id=postgres;Password=Wzrfdza8VjM3y86WTqdX;Database=TargetFrameworkCore;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"},
            {3,"Host=uat-db-01;User Id=postgres;Password=14244095dbbc6324c35067a045fd877e;Database=TargetFrameworkCore;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"}
        };
    }
}
