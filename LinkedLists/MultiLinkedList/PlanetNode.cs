namespace MultiLinkedList;

public class PlanetNode
{
	public required string Name { get; init; }
	public required decimal Mass { get; init; }
	public required decimal AverageTemperature { get; init; }
	public required decimal DistanceFromSum { get; init; }
	public required decimal Diameter { get; init; }
	public PlanetNode? NextPlanetByMass { get; internal set; }
	public PlanetNode? NextPlanetFromSun { get; internal set; }
	public PlanetNode? NextPlanetByTemperature { get; internal set; }
	public PlanetNode? NextPlanetByDiameter { get; internal set; }
    public override string ToString()
    {
        return $"""

			{Name}:
				Mass (kg "E+24"): {Mass}
				Average Temperature (C): {AverageTemperature}
				Distance From The Sun (km "E+6"): {DistanceFromSum}
				Diameter (km): {Diameter}
			
		""";
    }
}