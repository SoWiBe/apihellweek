namespace Extens.Core.Services;

public interface IValidationService
{
    bool CheckNullOrEmpty(IEnumerable<object> array); 
    bool CheckGuid(IEnumerable<object> array);
}