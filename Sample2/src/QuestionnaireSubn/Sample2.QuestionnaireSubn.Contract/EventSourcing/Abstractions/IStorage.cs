namespace Sample2.QuestionnaireSubn.Contract.EventSourcing.Abstractions;

public interface IStorage<out T>
    where T : AggregateRoot, new()
{
    void Save(AggregateRoot aggregate, int expectedVersion);

    T GetById(IIdentity id);
}