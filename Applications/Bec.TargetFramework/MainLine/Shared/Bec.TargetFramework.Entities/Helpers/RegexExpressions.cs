using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.Helpers
{
    public class RegexExpressions
    {
        public const string EmailExpression = @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";

        public const string UkTelephoneExpression = @"^\s*\(?(020[78]?\)? ?[1-9][0-9]{2,3} ?[0-9]{4})$|^(0[1-8][0-9]{3}\)? ?[1-9][0-9]{2} ?[0-9]{3})\s*$";

        public const string UKMobileExpression  =@"^(07\d{8,12}|447\d{7,11})$";

        public const string UKPostCode = @"^(((([A-PR-UWYZ][0-9][0-9A-HJKS-UW]?)|([A-PR-UWYZ][A-HK-Y][0-9][0-9ABEHMNPRV-Y]?))\s{0,2}[0-9]([ABD-HJLNP-UW-Z]{2}))|(GIR\s{0,2}0AA))$";

        public const string CardNumberExpression = @"^([0-9]{13,19})$";

        public const string CardExpMonthExpression = @"^(0[1-9])|(1[0-2])$";

        public const string CardExpYearExpression = @"^([0-9]{2})$";

        public const string CardCodeValueExpression = @"^([0-9]{3,4}|)$";

        public const string MandateReferenceExpression = @"^([A-Za-z0-9+?/\\:().,'-]{1,35})$";

        public const string IpExpression = @"^((25[0-5]|(2[0-4]|1[0-9]|[1-9])?[0-9])\.){3}(25[0-5]|(2[0-4]|1[0-9]|[1-9])?[0-9])|$";

        public const string ReferenceNumberExpression = @"^(NEW)?[0-9a-zA-Z]{1,8}$";

        public const string TDateExpression = @"^[0-9]{10}|$";

        public const string TerminalIDExpression = @"^[0-9]{10}|$";

        public const string CLCBranchNumberExpression = @"^([0-9]{6}|)$";

        public const string CLCNumberExpression = @"^([0-9]{5,6}|)$";

        public const string SRANumberExpression = @"^([0-9a-zA-Z]{3,6}|)$";

        public const string UKBankAccount = @"^(\d){8}$";

        public const string VATNumber = @"^(\d){9}$";

        public const string WebsiteExpression = @"((http|https)\:\/\/)?[a-zA-Z0-9\.\/\?\:@\-_=#]+\.([a-zA-Z0-9\.\/\?\:@\-_=#])*";//+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$";

        public const string IsValidPassword = @"^(?=.*[A-Z])(?=.*\d)(?=.*([-!@#$%^&*.,?>])).+$"; //{10,50}  // @"^([0-9A-Z]{10,50}|)$"; // @"^([0-9A-Z-!@#$%^&*.,?>]|)$"; 

        public const string CRNNumberExpression = @"^([0-9a-zA-Z]{6,8}|)$";

        public const string IBANExpression = @"^DE(?:\s*[0-9a-zA-Z]\s*){20}$";

        public const string SwiftExpression = @"^[A-Z]{6}[A-Z0-9]{2}([A-Z0-9]{3})?$";




    }
}
