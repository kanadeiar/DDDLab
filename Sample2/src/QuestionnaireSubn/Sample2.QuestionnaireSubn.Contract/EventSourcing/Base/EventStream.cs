namespace Sample2.QuestionnaireSubn.Contract.EventSourcing.Base;

public record EventStream(ICollection<DomainEvent> Events, int Version);
