using System.Collections.Generic;
using System.Web.Http;
using CaryCrimes.Models;
using FileHelpers;
using System.Linq;
namespace CaryCrimes.Controllers
{
    public class CrimeController : ApiController
    {
        private static List<CrimeDetail> _crimeList;

        public CrimeController()
        {
            LoadCrimeData();
        }

        private void LoadCrimeData()
        {
            if (_crimeList == null)
            {
                _crimeList = new List<CrimeDetail>();
            }
            var engine = new FileHelperEngine(typeof(CrimeDetail));
            var crimesArray = engine.ReadString(CrimeData.Data) as CrimeDetail[];
            if (crimesArray != null && crimesArray.Length > 0)
            {
                _crimeList.AddRange(crimesArray.Reverse());
            }
        }

        //
        // GET: /Crime/

        public List<CrimeDetail> Get(string category)
        {
            var result=new List<CrimeDetail>();
            if (string.IsNullOrEmpty(category))
            {
                var result2 = _crimeList.Take(100).ToList();
                return result2;
            }

            var result1 = _crimeList.Where(t => t.Category == category).Take(100).ToList();
            return result1;

            //return string.IsNullOrEmpty(category) ? _crimeList : _crimeList.FindAll(t => t.Category == category);
        }

        public string[] GetCategories()
        {
            return CrimeData.Categories ;
        } 


    }
}