namespace Application.Abstractions.Messaging;

public interface IConverter<in TFrom, out TTo>
{
    TTo Convert(TFrom from);
}
