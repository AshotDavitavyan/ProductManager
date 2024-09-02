using ProductManager.Models;

namespace ProductManager.Repositories;

public interface IAdvertisementRepository
{
	IEnumerable<Advertisement> Advertisements { get; }
	void AddAdvertisement(Advertisement advertisement);
}

public class AdvertisementRepository : IAdvertisementRepository
{
	private List<Advertisement> _advertisements = new List<Advertisement>
	{
		new Advertisement { Title = "Apple", Notation = "Red", Price = 1.99m },
		new Advertisement { Title = "Orange", Notation = "Orange", Price = 2.99m },
		new Advertisement { Title = "Banana", Notation = "Yellow", Price = 0.99m },
		new Advertisement { Title = "Grape", Notation = "Purple", Price = 3.99m },
		new Advertisement { Title = "Watermelon", Notation = "Green", Price = 4.99m }
	};
	public IEnumerable<Advertisement> Advertisements => _advertisements;
	public void AddAdvertisement(Advertisement advertisement)
	{
		_advertisements.Add(advertisement);
	}
}