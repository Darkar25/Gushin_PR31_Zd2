using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaraphonSkills.Core
{
    public partial class Runner
    {
        public byte[] RunnerPicture { get
            {
                byte[] visibleImage;
                if (Img == null)
                {
                    visibleImage = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\", "\\Resources\\boy.png"));
                }
                else
                {
                    visibleImage = Img;
                }
                return visibleImage;
            } }

        public string Age { get 
            {
                return (DateTime.Now.Year - DateOfBirth.Year).ToString()+" Лет";
            } }

        public string RunnerFIO { get {
                return String.Format("{0} {1}", User.LastName, User.FirstName);
            } }
    }
}
