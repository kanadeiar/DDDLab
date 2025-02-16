namespace Sample2.QuestionnaireSubn.Contract.EventSourcing.Base;

public class EventStream(ICollection<DomainEvent> events, int version)
{
    public ICollection<DomainEvent> Events => events;

    public int Version => version;
}