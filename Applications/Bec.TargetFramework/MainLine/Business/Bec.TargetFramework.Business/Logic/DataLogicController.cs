using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Settings;
using System;
using System.Text;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class DataLogicController : LogicBase
    {
       // private const string ResourcePathPrefix = "Bec.TargetFramework.Business.Resources.Resources.";
        private Random RandGen = new Random();
        //private const string MaleFile = "dist.male.first.stripped";
        //private const string FemaleFile = "dist.female.first.stripped";
        //private const string LastNameFile = "dist.all.last.stripped";
        //private static string[] _maleFirstNames;
        //private static string[] _femaleFirstNames;
        //private static string[] _lastNames;
        //public string _strSearch;
        //public string _strSearchUrl;
        public TFSettingsLogicController Settings { get; set; }

        public DataLogicController()
        {
        }

        //#region StatusEnum

        //public List<VStatusTypeDTO> GetStatusType(string statusTypeEnum)
        //{
        //    List<VStatusTypeDTO> statustypes = null;

        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
        //    {
        //        var statusTypeQuery = scope.DbContext.VStatusTypes.Where(s => s.StatusTypeName.Equals(statusTypeEnum)).OrderBy(s=>s.StatusOrder) ;

        //        statustypes = VStatusTypeConverter.ToDtos(statusTypeQuery);//StatusTypeConverter.ToDtos(statusTypeQuery);

        //        Ensure.That(statustypes);
        //    }
        //    return statustypes;
        //}
        //#endregion

        //#region BaseNameGenerator
        //private static Stream ReadResourceStreamForFileName(string resourceFileName)
        //{
        //    return
        //        Assembly.GetExecutingAssembly()
        //            .GetManifestResourceStream(ResourcePathPrefix + resourceFileName);
        //}

        //protected static string[] ReadResourceByLine(string resourceFileName)
        //{
        //    var stream = ReadResourceStreamForFileName(resourceFileName);

        //    var list = new List<string>();

        //    var streamReader = new StreamReader(stream);
        //    string str;

        //    while ((str = streamReader.ReadLine()) != null)
        //    {
        //        if (str != string.Empty)
        //            list.Add(str);
        //    }

        //    return list.ToArray();
        //}
        //#endregion

        //#region PersonNameGenerator
        //private bool RandomlyPickIfNameIsMale
        //{
        //    get { return RandGen.Next(0, 2) == 0; }
        //}

        //public string GenerateRandomFirstAndLastName()
        //{
        //    return GenerateRandomFirstName() + ' ' + GenerateRandomLastName();
        //}

        public string GenerateRandomName()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 8; i++) sb.Append(RandGen.Next(10));
            return sb.ToString();

            //Prefix with Temp so that user doesn't get confused when a random name is generated
            //return "Temp" + GenerateRandomFirstName() + GenerateRandomLastName();
        }
        //public string GenerateRandomLastName()
        //{
        //    if (_lastNames == null)
        //        _lastNames = ReadResourceByLine(LastNameFile);
        //    var index = RandGen.Next(0, _lastNames.Length);

        //    return _lastNames[index];
        //}

        //public string GenerateRandomFirstName()
        //{
        //    return !RandomlyPickIfNameIsMale
        //        ? GenerateRandomFemaleFirstName()
        //        : GenerateRandomMaleFirstName();
        //}

        //public string GenerateRandomFemaleFirstName()
        //{
        //    if (_femaleFirstNames == null)
        //        _femaleFirstNames = ReadResourceByLine(FemaleFile);
        //    var index = RandGen.Next(0, _femaleFirstNames.Length);

        //    return _femaleFirstNames[index];
        //}

        //public string GenerateRandomMaleFirstName()
        //{
        //    if (_maleFirstNames == null)
        //        _maleFirstNames = ReadResourceByLine(MaleFile);
        //    var index = RandGen.Next(0, _maleFirstNames.Length);

        //    return _maleFirstNames[index];
        //}

        //public IEnumerable<string> GenerateMultipleFirstAndLastNames(int count)
        //{
        //    var list = new List<string>();

        //    for (var index = 0; index < count; ++index)
        //        list.Add(GenerateRandomFirstAndLastName());

        //    return list;
        //}

        //public IEnumerable<string> GenerateMultipleLastNames(int count)
        //{
        //    var list = new List<string>();

        //    for (var index = 0; index < count; ++index)
        //        list.Add(GenerateRandomLastName());

        //    return list;
        //}

        //public IEnumerable<string> GenerateMultipleFemaleFirstAndLastNames(int count)
        //{
        //    var list = new List<string>();

        //    for (var index = 0; index < count; ++index)
        //        list.Add(GenerateRandomFemaleFirstAndLastName());

        //    return list;
        //}

        //public IEnumerable<string> GenerateMultipleMaleFirstAndLastNames(int count)
        //{
        //    var list = new List<string>();

        //    for (var index = 0; index < count; ++index)
        //        list.Add(GenerateRandomMaleFirstAndLastName());

        //    return list;
        //}

        //public IEnumerable<string> GenerateMultipleFemaleFirstNames(int count)
        //{
        //    var list = new List<string>();

        //    for (var index = 0; index < count; ++index)
        //        list.Add(GenerateRandomFemaleFirstName());

        //    return list;
        //}

        //public IEnumerable<string> GenerateMultipleMaleFirstNames(int count)
        //{
        //    var list = new List<string>();

        //    for (var index = 0; index < count; ++index)
        //        list.Add(GenerateRandomMaleFirstName());

        //    return list;
        //}

        //public string GenerateRandomFemaleFirstAndLastName()
        //{
        //    return GenerateRandomFemaleFirstName() + GenerateRandomLastName();
        //}

        //public string GenerateRandomMaleFirstAndLastName()
        //{
        //    return GenerateRandomMaleFirstName() + GenerateRandomLastName();
        //}
        //#endregion
    }




}
