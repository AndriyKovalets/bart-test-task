namespace TestTask.Core.Inrerfaces.Services
{
    public interface IBaseService<TAddDto, TInfoDto, TUndateDto, TKey>
    {
        Task<TInfoDto> AddAsync(TAddDto addDto);
        Task<List<TInfoDto>> GetAllAsync();
        Task<TInfoDto> GetByKeyAsync(TKey key);
        Task<TInfoDto> UpdateAsync(TKey key, TUndateDto updateDto);
    }
}
