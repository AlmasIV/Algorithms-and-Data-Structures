using System.Numerics;
using System.Reflection;

namespace MultiLinkedList;

public class SolarSystemLinkedList
{
	public PlanetNode? FirstByMass { get; private set; }
	public PlanetNode? FirstByAverageTemperature { get; private set; }
	public PlanetNode? FirstByDistanceFromSun { get; private set; }
	public PlanetNode? FirstByDiameter { get; private set; }
	public void AddPlanet(PlanetNode node)
	{
		ArgumentNullException.ThrowIfNull(node);
		AddByMass(node);
		AddByAverageTemperature(node);
		AddByDistanceFromTheSun(node);
		AddByDiameter(node);
	}
	public void DisplayByMass()
	{
		PlanetNode? temp = FirstByMass;
		Console.WriteLine("\nDisplaying By Mass:");
		while (temp is not null)
		{
			Console.WriteLine(temp.ToString());
			temp = temp.NextPlanetByMass;
		}
	}
	public void DisplayByAverageTemperature()
	{
		PlanetNode? temp = FirstByAverageTemperature;
		Console.WriteLine("\nDisplaying By Average Temperature:");
		while (temp is not null)
		{
			Console.WriteLine(temp.ToString());
			temp = temp.NextPlanetByTemperature;
		}
	}
	public void DisplayByDistanceFromSun()
	{
		PlanetNode? temp = FirstByDistanceFromSun;
		Console.WriteLine("\nDisplaying By The Distance From The Sun:");
		while (temp is not null)
		{
			Console.WriteLine(temp.ToString());
			temp = temp.NextPlanetFromSun;
		}
	}
	public void DisplayByDiameter()
	{
		PlanetNode? temp = FirstByDiameter;
		Console.WriteLine("\nDisplaying By Diameter:");
		while (temp is not null)
		{
			Console.WriteLine(temp.ToString());
			temp = temp.NextPlanetByDiameter;
		}
	}
	private void AddByMass(PlanetNode node)
	{
		if (FirstByMass is null)
		{
			FirstByMass = node;
			return;
		}
		else
		{
			PlanetNode? temp = FirstByMass;
			PlanetNode? beforeTemp = null;
			while (temp is not null)
			{
				if (temp.Mass > node.Mass)
				{
					if (beforeTemp is not null)
					{
						beforeTemp.NextPlanetByMass = node;
					}
					else
					{
						FirstByMass = node;
					}
					node.NextPlanetByMass = temp;
					return;
				}
				beforeTemp = temp;
				temp = temp.NextPlanetByMass;
			}
			if (beforeTemp is not null)
			{
				beforeTemp.NextPlanetByMass = node;
			}
		}
	}
	private void AddByAverageTemperature(PlanetNode node)
	{
		if (FirstByAverageTemperature is null)
		{
			FirstByAverageTemperature = node;
			return;
		}
		else
		{
			PlanetNode? temp = FirstByAverageTemperature;
			PlanetNode? beforeTemp = null;
			while (temp is not null)
			{
				if (temp.AverageTemperature > node.AverageTemperature)
				{
					if (beforeTemp is not null)
					{
						beforeTemp.NextPlanetByTemperature = node;
					}
					else
					{
						FirstByAverageTemperature = node;
					}
					node.NextPlanetByTemperature = temp;
					return;
				}
				beforeTemp = temp;
				temp = temp.NextPlanetByTemperature;
			}
			if (beforeTemp is not null)
			{
				beforeTemp.NextPlanetByTemperature = node;
			}
		}
	}
	private void AddByDistanceFromTheSun(PlanetNode node)
	{
		if (FirstByDistanceFromSun is null)
		{
			FirstByDistanceFromSun = node;
			return;
		}
		else
		{
			PlanetNode? temp = FirstByDistanceFromSun;
			PlanetNode? beforeTemp = null;
			while (temp is not null)
			{
				if (temp.DistanceFromSum > node.DistanceFromSum)
				{
					if (beforeTemp is not null)
					{
						beforeTemp.NextPlanetFromSun = node;
					}
					else
					{
						FirstByDistanceFromSun = node;
					}
					node.NextPlanetFromSun = temp;
					return;
				}
				beforeTemp = temp;
				temp = temp.NextPlanetFromSun;
			}
			if (beforeTemp is not null)
			{
				beforeTemp.NextPlanetFromSun = node;
			}
		}
	}
	private void AddByDiameter(PlanetNode node)
	{
		if (FirstByDiameter is null)
		{
			FirstByDiameter = node;
			return;
		}
		else
		{
			PlanetNode? temp = FirstByDiameter;
			PlanetNode? beforeTemp = null;
			while (temp is not null)
			{
				if (temp.Diameter > node.Diameter)
				{
					if (beforeTemp is not null)
					{
						beforeTemp.NextPlanetByDiameter = node;
					}
					else
					{
						FirstByDiameter = node;
					}
					node.NextPlanetByDiameter = temp;
					return;
				}
				beforeTemp = temp;
				temp = temp.NextPlanetByDiameter;
			}
			if (beforeTemp is not null)
			{
				beforeTemp.NextPlanetByDiameter = node;
			}
		}
	}
}