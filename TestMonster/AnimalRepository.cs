using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TestMonster.Models; 

public class AnimalRepository
{
	private readonly string _connectionString;

	public AnimalRepository(IConfiguration configuration)
	{	
		_connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
	}

	public async Task<IEnumerable<Animal>> GetAllAnimalsAsync()
	{
		using (IDbConnection db = new MySqlConnection(_connectionString))
		{
			return await db.QueryAsync<Animal>("SELECT * FROM animals");
		}
	}

	public async Task AddAnimalAsync(Animal animal)
	{
		using (IDbConnection db = new MySqlConnection(_connectionString))
		{
			var sqlQuery = "INSERT INTO animals (MonsterName, MonsterDescription, Environment, HitPoints, ArmorClass, Size, CreatureType, Alignment, Speed, Saves, Feats, ChallengeRating, BaseAttack, Grapple, FullAttack, SpecialAttack, ImageUrl) VALUES (@MonsterName, @MonsterDescription, @Environment, @HitPoints, @ArmorClass, @Size, @CreatureType, @Alignment, @Speed, @Saves, @Feats, @ChallengeRating, @BaseAttack, @Grapple, @FullAttack, @SpecialAttack, @ImageUrl)";
			await db.ExecuteAsync(sqlQuery, animal);
		}
	}
    public async Task DeleteAllAnimalsAsync()
    {
        using (IDbConnection db = new MySqlConnection(_connectionString))
        {
            await db.ExecuteAsync("DELETE FROM animals");
        }
    }


    // Additional repository methods can be added here as needed
}
