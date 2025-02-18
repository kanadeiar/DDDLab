namespace Easy.Questionnaire.Contract.EventSourcing.Base;

public record EventStream(ICollection<DomainEvent> Events, int Version);