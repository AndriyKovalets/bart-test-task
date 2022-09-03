using AutoMapper;
using TestTask.Core.Inrerfaces.Repisitories;
using TestTask.Core.Inrerfaces.Services;
using TestTask.Domain.Entities;
using TestTask.Domain.Exceptions;

namespace TestTask.Core.Services
{
    internal abstract class BaseService<TAddDto, TInfoDto, TUndateDto, TKey, TEntity>
        : IBaseService<TAddDto, TInfoDto, TUndateDto, TKey>
            where TEntity: class, IBaseEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TInfoDto> AddAsync(TAddDto addDto)
        {
            var entityToAdd = _mapper.Map<TEntity>(addDto);

            await _repository.AddAsync(entityToAdd);
            await _repository.SaveChangesAsync();

            return _mapper.Map<TInfoDto>(entityToAdd);
        }

        public virtual async Task<List<TInfoDto>> GetAllAsync()
        {
            var entityList = await _repository.GetAllAsync();

            return _mapper.Map<List<TInfoDto>>(entityList);
        }

        public virtual async Task<TInfoDto> GetByKeyAsync(TKey key)
        {
            var entity = await _repository.GetByKeyAsync(key);

            if (entity is null)
            {
                throw new NotFoundHttpException($"{typeof(TEntity).Name} with this key not found");
            }

            return _mapper.Map<TInfoDto>(entity);
        }

        public virtual async Task<TInfoDto> UpdateAsync(TKey key, TUndateDto undateDto)
        {
            var entity = await _repository.GetByKeyAsync(key);

            if (entity is null)
            {
                throw new NotFoundHttpException($"{typeof(TEntity).Name} with this key not found");
            }

            _mapper.Map(undateDto, entity);

            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<TInfoDto>(entity);
        }
    }
}
