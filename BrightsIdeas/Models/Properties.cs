using System.Collections.Generic;

namespace BrightsIdeas.Api.Models
{
    //public class Rootobject
    //{
        //public Properties properties { get; set; }
    //}

    //public class Properties
    //{
        //public Property1[] property { get; set; }
    //}

    public class Properties
    {
        public string PropertyId { get; set; }
        public string branchID { get; set; }
        public string clientName { get; set; }
        public string branchName { get; set; }
        public string Department { get; set; }
        public string referenceNumber { get; set; }
        public string addressName { get; set; }
        public string addressNumber { get; set; }
        public string addressStreet { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string address4 { get; set; }
        public string addressPostcode { get; set; }
        public string country { get; set; }
        public string DisplayAddress { get; set; }
        public string propertyBedrooms { get; set; }
        public string propertyBathrooms { get; set; }
        public string propertyEnsuites { get; set; }
        public string propertyReceptionRooms { get; set; }
        public string propertyKitchens { get; set; }
        public string displayPropertyType { get; set; }
        public string propertyType { get; set; }
        public string propertyStyle { get; set; }
        public string propertyAge { get; set; }
        public string floorArea { get; set; }
        public string floorAreaUnits { get; set; }
        public string propertyFeature1 { get; set; }
        public string propertyFeature2 { get; set; }
        public string propertyFeature3 { get; set; }
        public string propertyFeature4 { get; set; }
        public string propertyFeature5 { get; set; }
        public string propertyFeature6 { get; set; }
        public string propertyFeature7 { get; set; }
        public string propertyFeature8 { get; set; }
        public string propertyFeature9 { get; set; }
        public string propertyFeature10 { get; set; }
        public string Price { get; set; }
        public string forSalePOA { get; set; }
        public string priceQualifier { get; set; }
        public string propertyTenure { get; set; }
        public string saleBy { get; set; }
        public string developmentOpportunity { get; set; }
        public string investmentOpportunity { get; set; }
        public string estimatedRentalIncome { get; set; }
        public string availability { get; set; }
        public string MainSummary { get; set; }
        public string fullDescription { get; set; }
        public string dateLastModified { get; set; }
        public string timeLastModified { get; set; }
        public string featuredProperty { get; set; }
        public string regionID { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public object flags { get; set; }
        public List<string> Images { get; set; }
        public object floorplans { get; set; }
        public Epc epc { get; set; }
        public object epcGraphs { get; set; }
        public string epcFrontPages { get; set; }
        public object brochures { get; set; }
        public string virtualTours { get; set; }
        public string externalLinks { get; set; }
        public string rent { get; set; }
        public string rentFrequency { get; set; }
        public string toLetPOA { get; set; }
        public string studentProperty { get; set; }
        public string forSale { get; set; }
        public string toLet { get; set; }
        public string priceTo { get; set; }
        public string priceFrom { get; set; }
        public string rentTo { get; set; }
        public string rentFrom { get; set; }
        public string floorAreaTo { get; set; }
        public string floorAreaFrom { get; set; }
        public string siteArea { get; set; }
        public string siteAreaUnits { get; set; }
        public string strapLine { get; set; }
        public Propertytypes propertyTypes { get; set; }
    }

    public class Images
    {
        public Image[] image { get; set; }
    }

    public class Image
    {
        public string _modified { get; set; }
        public string __text { get; set; }
    }

    public class Epc
    {
        public string buildingName { get; set; }
        public string eerCurrentLetter { get; set; }
        public string eerCurrentValue { get; set; }
        public string eerPotentialLetter { get; set; }
        public string eerPotentialValue { get; set; }
        public string eirCurrentLetter { get; set; }
        public string eirCurrentValue { get; set; }
        public string eirPotentialLetter { get; set; }
        public string eirPotentialValue { get; set; }
    }

    public class Propertytypes
    {
        public string propertyType { get; set; }
    }

}
