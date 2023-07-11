using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPredictionApp.Domain.Model
{
    //[Newtonsoft.Json.JsonArray]
    //public class CountryDetailsResponse
    //{
    //    public Class1[] Property1 { get; set; }
    //}




    public class CountryDetailsResponse 
    {
        public CountryDetails[] Property1 { get; set; }
    }

    public class CountryDetails
    {
        public Name name { get; set; }
        public string[] tld { get; set; }
        public string cca2 { get; set; }
        public string ccn3 { get; set; }
        public string cca3 { get; set; }
        public string cioc { get; set; }
        public bool independent { get; set; }
        public string status { get; set; }
        public bool unMember { get; set; }
        public Currencies currencies { get; set; }
        public Idd idd { get; set; }
        public string[] capital { get; set; }
        public string[] altSpellings { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public Languages languages { get; set; }
        public Translations translations { get; set; }
        public float[] latlng { get; set; }
        public bool landlocked { get; set; }
        public string[] borders { get; set; }
        public float area { get; set; }
        public Demonyms demonyms { get; set; }
        public string flag { get; set; }
        public Maps maps { get; set; }
        public int population { get; set; }
        public Gini gini { get; set; }
        public string fifa { get; set; }
        public Car car { get; set; }
        public string[] timezones { get; set; }
        public string[] continents { get; set; }
        public Flags flags { get; set; }
        public Coatofarms coatOfArms { get; set; }
        public string startOfWeek { get; set; }
        public Capitalinfo capitalInfo { get; set; }
        public Postalcode postalCode { get; set; }
    }

    public class Name
    {
        public string common { get; set; }
        public string official { get; set; }
        public Nativename nativeName { get; set; }
    }

    public class Nativename
    {
        public Eng eng { get; set; }
    }

    public class Eng
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Currencies
    {
        public CurrencyName Name { get; set; }
    }

    public class CurrencyName
    {
        public string name { get; set; }
        public string symbol { get; set; }
    }

    public class Idd
    {
        public string root { get; set; }
        public string[] suffixes { get; set; }
    }

    public class Languages
    {
        public string eng { get; set; }
    }

    public class Translations
    {
        public Ara ara { get; set; }
        public Bre bre { get; set; }
        public Ces ces { get; set; }
        public Cym cym { get; set; }
        public Deu deu { get; set; }
        public Est est { get; set; }
        public Fin fin { get; set; }
        public Fra fra { get; set; }
        public Hrv hrv { get; set; }
        public Hun hun { get; set; }
        public Ita ita { get; set; }
        public Jpn jpn { get; set; }
        public Kor kor { get; set; }
        public Nld nld { get; set; }
        public Per per { get; set; }
        public Pol pol { get; set; }
        public Por por { get; set; }
        public Rus rus { get; set; }
        public Slk slk { get; set; }
        public Spa spa { get; set; }
        public Srp srp { get; set; }
        public Swe swe { get; set; }
        public Tur tur { get; set; }
        public Urd urd { get; set; }
        public Zho zho { get; set; }
    }

    public class Ara
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Bre
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Ces
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Cym
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Deu
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Est
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Fin
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Fra
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Hrv
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Hun
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Ita
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Jpn
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Kor
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Nld
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Per
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Pol
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Por
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Rus
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Slk
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Spa
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Srp
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Swe
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Tur
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Urd
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Zho
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Demonyms
    {
        public Eng1 eng { get; set; }
        public Fra1 fra { get; set; }
    }

    public class Eng1
    {
        public string f { get; set; }
        public string m { get; set; }
    }

    public class Fra1
    {
        public string f { get; set; }
        public string m { get; set; }
    }

    public class Maps
    {
        public string googleMaps { get; set; }
        public string openStreetMaps { get; set; }
    }

    public class Gini
    {
        public float _2018 { get; set; }
    }

    public class Car
    {
        public string[] signs { get; set; }
        public string side { get; set; }
    }

    public class Flags
    {
        public string png { get; set; }
        public string svg { get; set; }
        public string alt { get; set; }
    }

    public class Coatofarms
    {
        public string png { get; set; }
        public string svg { get; set; }
    }

    public class Capitalinfo
    {
        public float[] latlng { get; set; }
    }

    public class Postalcode
    {
        public string format { get; set; }
        public string regex { get; set; }
    }

}
