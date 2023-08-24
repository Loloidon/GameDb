using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataAccessLayer
{
    public class Game
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public DateTime AnneeSortie { get; set; }
        public string Synopsis { get; set; }
        public int CategorieID { get; set; }
    }
}
