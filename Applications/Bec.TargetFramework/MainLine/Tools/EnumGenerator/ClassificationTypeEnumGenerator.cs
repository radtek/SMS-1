using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumGenerator
{
    public class ClassificationTypeEnumGenerator
    {
        private List<ClassificationType> m_ClassificationTypes;
        private List<ClassificationTypeCategory> m_ClassificationTypeCategories;
        private string m_FileName;

        public void Initialize(string fileName)
        {
            m_FileName = fileName;

            using (
                var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading,
                    null))
            {
                m_ClassificationTypes = scope.DbContext.ClassificationTypes.ToList();
                m_ClassificationTypeCategories = scope.DbContext.ClassificationTypeCategories.ToList();
            }
        }

        private string CleanName(string name)
        {
            return name.Trim().Replace(" ", "_").Replace("-", "").Replace("(", "").Replace(")", "").Replace("?", "");
        }

        public void Generate()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using Bec.TargetFramework.Infrastructure.Extensions;");
            sb.AppendLine("");
            sb.AppendLine("namespace Bec.TargetFramework.Entities.Enums");
            sb.AppendLine("{");

            m_ClassificationTypeCategories.ForEach(item =>
                {
                    var types = m_ClassificationTypes.Where(ct => ct.ClassificationTypeCategoryID.Equals(item.ClassificationTypeCategoryID)).ToList();

                    if(types.Count > 0)
                    {
                        sb.AppendLine("    public enum " + CleanName(item.Name) + "Enum : int");
                        sb.AppendLine("    {");

                        if (types.Count > 1)
                        {
                            types.GetRange(0, types.Count - 1).ToList().ForEach(ct =>
                            {
                                sb.AppendLine(@"        [StringValue(""" + ct.Name + @""")]");
                                sb.AppendLine("        " + CleanName(ct.Name) + " = " + ct.ClassificationTypeID + ",");
                            });

                            var ctLast = types.Last();

                            sb.AppendLine(@"        [StringValue(""" + ctLast.Name + @""")]");
                            sb.AppendLine("        " + CleanName(ctLast.Name) + " = " + ctLast.ClassificationTypeID);
                        }
                        else if (types.Count == 1)
                        {
                            var ctLast = types.Last();

                            sb.AppendLine(@"        [StringValue(""" + ctLast.Name + @""")]");
                            sb.AppendLine("        " + CleanName(ctLast.Name) + " = " + ctLast.ClassificationTypeID);
                        }

                        sb.AppendLine("    }");
                    }

                });

            sb.AppendLine("    }");

            using(var fs = File.OpenWrite(m_FileName))
            {
                using(var sw = new StreamWriter(fs))
                {
                    sw.Write(sb.ToString());

                    sw.Close();

                }

                fs.Close();
            }

        }

    }
}
