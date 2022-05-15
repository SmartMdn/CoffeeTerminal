using System.Configuration;
using CoffeeTerminal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeTerminal.EntityFramework.Services;

public class RegistrationService : GenericDataService<Terminal>
{
    public RegistrationService(CoffeeTerminalDbContextFactory contextFactory) : base(contextFactory)
    {
    }

    public bool IsRegistered { get; set; }

    /// <summary>
    ///     Производит проверку на наличие Id в БД и в случае успеха, производит регистрацию и возвращает true. Если же
    ///     терминал с таким Id не найден, возвращает false
    /// </summary>
    /// <param name="id">Id терминала, по которому нужно производить поиск</param>
    /// <returns>Возвращает false при неудачной регистрации, true если регистрация прошла успешно</returns>
    public async Task<bool> Registration(string terminalId)
    {
        var entity = await Get(terminalId);
        if (entity == null) return false;
        entity.RegistrationDateTime = DateTime.Now;
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        config.AppSettings.Settings["isRegistered"].Value = "true";
        config.Save(ConfigurationSaveMode.Modified);
        await Update(entity.Id, entity);
        return true;
    }

    public async Task<Terminal?> Get(string terminalId)
    {
        var entity = await Context.Set<Terminal>().FirstOrDefaultAsync(e => e.TerminalId == terminalId);
        if (entity == null) return null;
        IsRegistered = true;
        return entity;
    }
}