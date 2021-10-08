using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public enum GenderEnum
    {
        MALE,
        FEMALE
    }
    public class Person
    {
        //string meno;
        int? vek;
        //GenderEnum pohlavi;

        /*public string Meno
        {
            get => meno;
            set => meno = value;
        }*/
        public string Meno { get; set; }
        public int? Vek
        {
            get { return this.vek; }
            set {
                if (value > 0 && value < 150)
                {
                    this.vek = value;
                }
                else
                {
                    this.vek = null;
                }
            }
        } 
        public bool Adult
        {
            get { return this.vek >= 18; }
        }
        public GenderEnum? Pohlavi
        {
            get; set;
        }

        public override string ToString()
        {
            StringBuilder s0 = new StringBuilder();
            s0.Append("Jmeno: ").AppendLine(this.Meno);
            s0.Append("Vek: ").AppendLine(this.Vek.ToString());
            s0.Append("Pohlavi: ").AppendLine(this.Pohlavi.ToString());
            s0.Append("Je dospely: ").AppendLine(this.Adult.ToString());
            return s0.ToString();
        }
        /*public Person(string _meno)
        {
            Meno = _meno;
        }
        
        public Person(string _meno, int _vek) : this(_meno)
        {
            Vek = _vek;
        } 
        public Person(string _meno, GenderEnum _gender) : this(_meno)
        {
            Pohlavi = _gender;
        } 
        public Person(string _meno, int _vek, GenderEnum _gender) : this(_meno, _vek)
        {
            Pohlavi = _gender;
        }*/
    }
    public class PopulationDatabase
    {
        private int populationSize = 0;
        private Person[] person_arr = new Person[2];
        public void Add(Person p) {
            if (this.populationSize == this.person_arr.Length)
            {
                Array.Resize(ref this.person_arr, this.person_arr.Length + 3);
            }
            this.person_arr[this.populationSize] = p;
            this.populationSize++;
        }
        public int Count
        {
            get
            {
                return this.populationSize;
            }
        }
        public int AdultCount
        {
            get
            {
                int adultCount = 0;
                for (int i = 0; i < this.populationSize; i++)
                {
                    if (this.person_arr[i].Adult)
                    {
                        adultCount++;
                    }
                }
                return adultCount;
            }
        }
        public void PrintArr()
        {
            for (int i = 0; i < this.populationSize; i++)
            {
                Console.WriteLine(this.person_arr[i].ToString());
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Velkost populacie :").AppendLine(this.Count.ToString());
            sb.Append("Pocet dospelych :").AppendLine(this.AdultCount.ToString());
            sb.Append("Priemerny vek :").AppendLine(this.GetAverageAge().ToString());
            sb.Append("===============").AppendLine();
            for (int i = 0; i < this.populationSize; i++)
            {
                sb.AppendLine(this.person_arr[i].ToString());
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public double? GetAverageAge()
        {
            int sum = 0;
            int count = 0;
            for (int i = 0; i < this.populationSize; i++)
            {
                if (this.person_arr[i].Vek != null)
                {
                    count++;
                    sum += this.person_arr[i].Vek.Value;
                }
            }
            if (count == 0)
            {
                return null;
            }
            return sum / (double)count;
        }
    }
    public class DatabaseClass
    {
        public void Run()
        {
            Person a = new Person() {
                Meno = "Jano",
                Vek = 15,
                Pohlavi = GenderEnum.MALE
            };
            Person b = new Person() {
                Meno = "Petra",
                Vek = 51,
                Pohlavi = GenderEnum.FEMALE
            };
            Person c = new Person() {
                Meno = "Fero",
                Vek = 80,
                Pohlavi = GenderEnum.MALE
            };
            Person d = new Person() {
                Meno = "Tono",
                Vek = 19,
                Pohlavi = GenderEnum.MALE
            };
            Person e = new Person() {
                Meno = "Misa",
                Vek = 11,
                Pohlavi = GenderEnum.FEMALE
            };

            PopulationDatabase pd = new PopulationDatabase();
            pd.Add(a);
            pd.Add(b);
            pd.Add(c);
            pd.Add(d);
            pd.Add(e);

            Console.WriteLine(pd.ToString());
            

        }
        
    }
}
