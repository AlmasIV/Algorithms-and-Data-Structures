namespace MultiLinkedList;

class Program
{
    static void Main(string[] args)
    {
        PlanetNode[] planets = new PlanetNode[]{
            new PlanetNode(){
                Name = "Mercury",
                Mass = 0.330m,
                AverageTemperature = 167,
                DistanceFromSum = 57.9m,
                Diameter = 4879
            },
            new PlanetNode(){
                Name = "Venus",
                Mass = 4.87m,
                AverageTemperature = 464,
                DistanceFromSum = 108.2m,
                Diameter = 12104
            },
            new PlanetNode(){
                Name = "Earth",
                Mass = 5.97m,
                AverageTemperature = 15,
                DistanceFromSum = 149.6m,
                Diameter = 12756
            },
            new PlanetNode(){
                Name = "Moon",
                Mass = 0.073m,
                AverageTemperature = -20,
                DistanceFromSum = 0.384m,
                Diameter = 3475
            },
            new PlanetNode(){
                Name = "Mars",
                Mass = 0.642m,
                AverageTemperature = -65,
                DistanceFromSum = 228m,
                Diameter = 6792
            },
            new PlanetNode(){
                Name = "Jupiter",
                Mass = 1898m,
                AverageTemperature = -110,
                DistanceFromSum = 778.5m,
                Diameter = 142984
            },
            new PlanetNode(){
                Name = "Saturn",
                Mass = 568m,
                AverageTemperature = -140,
                DistanceFromSum = 1432m,
                Diameter =120536
            },
            new PlanetNode(){
                Name = "Uranus",
                Mass = 86.8m,
                AverageTemperature = -195,
                DistanceFromSum = 2867m,
                Diameter = 51118
            },
            new PlanetNode(){
                Name = "Neptune",
                Mass = 102m,
                AverageTemperature = -200,
                DistanceFromSum = 4471.1m,
                Diameter = 49528
            },
        };

        SolarSystemLinkedList solarSystemLinkedList = new SolarSystemLinkedList();
        foreach (PlanetNode planetNode in planets)
        {
            solarSystemLinkedList.AddPlanet(planetNode);
        }

        solarSystemLinkedList.DisplayByMass();
        solarSystemLinkedList.DisplayByAverageTemperature();
        solarSystemLinkedList.DisplayByDistanceFromSun();
        solarSystemLinkedList.DisplayByDiameter();
    }
}
