using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaraphonSkills.Core.ModelAPI
{
    public class Charity
    {
        public int CharityId { get; set; }
        public string CharityName { get; set; }
        public string CharityDescription { get; set; }
        public byte[] CharitiLogo { get; set; }

        public byte[] Logo
        {
            get
            {
                byte[] visibleLogo;
                if (CharitiLogo == null)
                {
                    // Замена пустого значения изображения на стандартное изображение
                    string thisPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\", "\\Resources\\cross.png");
                    visibleLogo = File.ReadAllBytes(thisPath);

                }
                else
                {
                    visibleLogo = CharitiLogo;
                }

                return visibleLogo;
            }
        }
    }
}
