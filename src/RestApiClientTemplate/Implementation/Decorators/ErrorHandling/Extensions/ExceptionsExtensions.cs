using Microsoft.Extensions.Logging;
using Refit;
using RestApiClientTemplate.Exceptions;

namespace RestApiClientTemplate.Implementation.Decorators.ErrorHandling.Extensions;

internal static class ExceptionsExtensions
{
    /// <summary>
    /// Handles the no exception.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <returns>Exception</returns>
    /// <exception cref="Lvp.Kdv.UserActivities.SearchApiClient.Exceptions.InternalException">Unknown Fault</exception>
    public static Exception HandleNoException(this Exception? exception)
    {
        if (exception == null)
        {
            throw new InternalException("Unknown Fault");
        }
        return exception;
    }

    /// <summary>
    /// Handles the inner exceptions.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <returns>Exception</returns>
    public static Exception HandleInnerExceptions(this Exception exception)
    {
        if (exception is InternalException || exception is ValidationException)
        {
            throw exception;
        }
        return exception;
    }

    /// <summary>
    /// Handles the validation exceptions.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="logger">The logger.</param>
    /// <returns>Exception</returns>
    /// <exception cref="Lvp.Kdv.UserActivities.SearchApiClient.Exceptions.ValidationException"></exception>
    public static Exception HandleValidationExceptions(this Exception exception, ILogger logger)
    {
        if (exception is FluentValidation.ValidationException validationException)
        {
            logger.LogError(validationException, validationException.Message);
            throw new ValidationException(validationException.Message, validationException);
        }
        return exception;
    }

    /// <summary>
    /// Handles the bad request API exception.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="logger">The logger.</param>
    /// <returns>Exception</returns>
    /// <exception cref="Lvp.Kdv.UserActivities.SearchApiClient.Exceptions.ValidationException"></exception>
    public static Exception HandleBadRequestApiException(this Exception exception, ILogger logger)
    {
        if (exception is ApiException badrequestApiException && badrequestApiException.StatusCode == System.Net.HttpStatusCode.BadRequest)
        {
            logger.LogError(badrequestApiException, badrequestApiException.Message);
            throw new ValidationException(badrequestApiException.Message);
        }
        return exception;
    }

    /// <summary>
    /// Handles the unauthorized API exception.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="logger">The logger.</param>
    /// <returns>Exception</returns>
    /// <exception cref="Lvp.Kdv.UserActivities.SearchApiClient.Exceptions.UnauthorizedException"></exception>
    public static Exception HandleUnauthorizedApiException(this Exception exception, ILogger logger)
    {
        if (exception is ApiException unauthorizedApiException && unauthorizedApiException.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            logger.LogError(unauthorizedApiException, unauthorizedApiException.Message);
            throw new UnauthorizedException(unauthorizedApiException.Message, unauthorizedApiException);
        }
        return exception;
    }

    /// <summary>
    /// Handles the forbidden API exception.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="logger">The logger.</param>
    /// <returns>Exception</returns>
    /// <exception cref="Lvp.Kdv.UserActivities.SearchApiClient.Exceptions.PermissionDeniedException"></exception>
    public static Exception HandleForbiddenApiException(this Exception exception, ILogger logger)
    {
        if (exception is ApiException forbiddenApiException && forbiddenApiException.StatusCode == System.Net.HttpStatusCode.Forbidden)
        {
            logger.LogError(forbiddenApiException, forbiddenApiException.Message);
            throw new PermissionDeniedException(forbiddenApiException.Message, forbiddenApiException);
        }
        return exception;
    }

    /// <summary>
    /// Handles the API exception.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="logger">The logger.</param>
    /// <returns>Exception</returns>
    /// <exception cref="Lvp.Kdv.UserActivities.SearchApiClient.Exceptions.InternalException"></exception>
    public static Exception HandleApiException(this Exception exception, ILogger logger)
    {
        if (exception is ApiException apiException)
        {
            logger.LogError(apiException, apiException.Message);
            throw new InternalException(apiException.Message, apiException.Content, apiException.StatusCode, apiException);
        }
        return exception;
    }

    /// <summary>
    /// Handles the exception.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="logger">The logger.</param>
    /// <exception cref="Lvp.Kdv.UserActivities.SearchApiClient.Exceptions.InternalException"></exception>
    public static void HandleException(this Exception exception, ILogger logger)
    {
        logger.LogError(exception, exception?.Message);
        throw new InternalException(exception!.Message, exception);
    }
}
