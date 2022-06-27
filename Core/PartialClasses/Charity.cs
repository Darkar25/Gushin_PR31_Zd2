using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaraphonSkills.Core
{
    public partial class Charity
    {
        /// <summary>
        /// Переменная для отображения изображения CharitiLogo из базы данных в приложении
        /// </summary>
        public byte[] Logo { get
            {
                byte[] visibleLogo;
                if (CharitiLogo == null)
                {
                    // Замена пустого значения изображения на стандартное изображение
                    string thisPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\", "\\Resources\\boy.png");
                    visibleLogo = File.ReadAllBytes(thisPath);

                }
                else
                {
                    visibleLogo = CharitiLogo;
                }

                return visibleLogo;
            } 
        }

        public int MoneyCount { get
            {
                int charityID = CharityId;
                int moneyCount = 0;
                var allDonations = Sponsor.Where(x => x.CharityId == charityID).ToList();
                foreach (var item in allDonations)
                {
                    moneyCount += Convert.ToInt32(item.Amount);
                }
                return moneyCount;
            }
        }
    }
}
