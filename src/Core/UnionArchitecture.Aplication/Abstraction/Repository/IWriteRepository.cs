using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Aplication.Abstraction.Repository;

public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity,new()
{
    Task AddAsync(T entity); // bir entity gelir servicesden son onu add edirsen bu qeder Sade 
    Task AddRangeAsync(ICollection<T> entites); // bir cox entitler gelir add elemk ucun o zaman AddRangeAsync etmelisem
    void Remove(T entity); // bir entity gelir servicesden son onu Remove edirsen bu qeder Sade 
    void RemoveRange(ICollection<T> entites); // bir cox entitler gelir Remove elemk ucun o zaman RemoveRange etmelisem
    void Update(T entity); // bir entity gelir ve update edirsen
    Task SaveChangeAsync(); // SaveChangeAsync edirsen axi sonda o 
}
