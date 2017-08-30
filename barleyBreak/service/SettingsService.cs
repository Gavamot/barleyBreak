using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barleyBreak.service
{
    public class SettingsService
    {
        private static readonly SettingsService instance = new SettingsService();

        SettingsService()
        {
            Load();
            difficulIndex = DifficultLevels.IndexOf(Difficult);
        }

        public static SettingsService Instance => instance;
        public const char Seporator = '=';
        public readonly string FileName = AppDomain.CurrentDomain.BaseDirectory + "settings";

        private const string FieldName = "name";
        private const string FieldDifficul = "difficul";


        private int difficulIndex;
        public string GetNextDifficul()
        {
            int max = DifficultLevels.Count - 1;
            difficulIndex++;
            if (difficulIndex < 0)
            {
                difficulIndex = max;
                return DifficultLevels[max];
            }
            if(difficulIndex > max)
            {
                difficulIndex = 0;
                return DifficultLevels[0];
            }
            return DifficultLevels[difficulIndex];
        }

        public void Load()
        {
            try
            {
                string[] text = System.IO.File.ReadAllLines(FileName);
                foreach(string str in text)
                {
                    string[] propVal = str.Split(Seporator);
                    string prop = propVal[0].Trim();
                    string val = propVal[1].Trim();

                    if (prop.Equals(FieldName))
                    {
                        Name = val;
                    }
                    if (prop.Equals(FieldDifficul))
                    {
                        Difficult = val;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private string GetProp(string fieldName, string value)
        {
            return $"{fieldName}{Seporator}{value} \n";
        }

        public void Save()
        {
            string text = GetProp(FieldName, Name) + GetProp(FieldDifficul, Difficult);
            try {
                System.IO.File.WriteAllText(FileName, text);
            }catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        private string name = "Vasia";
        public string Name
        {
            get { return name; }
            set { name = value.Replace(Seporator.ToString(), "").Trim(); }
        }

        private const string Middle = "Middle";
        private readonly List<string> DifficultLevels = new List<string> {
            "Easy",
            Middle,
            "Hard"
        };


        public int MapSize { get { return 3 + DifficultLevels.IndexOf(Difficult); } }

        private string difficult = Middle;
        public string Difficult
        {
            get
            {
               return difficult;
            }
            set
            {
                value = value.Trim();
                if (DifficultLevels.Contains(value))
                    difficult = value;
                else
                    difficult = Middle;
            }
        }
    }
}
