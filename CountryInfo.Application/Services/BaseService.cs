using AutoMapper;
using CountryInfo.Core.Common;
using CountryInfo.Core.Enums;

namespace CountryInfo.Application.Services
{
    public abstract class BaseService(IMapper mapper)
    {
        protected readonly IMapper _mapper = mapper;

        /// <summary>
        /// Handles API calls that return a list of entities, mapping the result to a DTO.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to map the result to.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being returned by the API call.</typeparam>
        /// <param name="apiCallTask">The task representing the API call that returns a list of entities.</param>
        /// <param name="successMessage">The message to return if the API call is successful.</param>
        /// <param name="notFoundMessage">The message to return if no entities are found.</param>
        /// <param name="additionalMapping">An optional function to perform additional mapping from the entity list to the DTO.</param>
        /// <returns>A <see cref="NewResult{TDto}"/> containing the mapped DTO and a response code indicating the result of the API call.</returns>
        protected async Task<NewResult<TDto>> HandleApiCall<TDto, TEntity>(Task<NewResult<List<TEntity>>> apiCallTask, string successMessage, string notFoundMessage, Func<List<TEntity>, TDto> additionalMapping = null)
        {
            try
            {
                var apiResult = await apiCallTask;

                if (apiResult.ResponseCode == HttpResponseCode.Success && apiResult.ResponseDetails != null)
                {
                    TDto resultDto;
                    if (additionalMapping != null)
                    {
                        resultDto = additionalMapping(apiResult.ResponseDetails);
                    }
                    else
                    {
                        resultDto = _mapper.Map<TDto>(apiResult.ResponseDetails);
                    }
                    return NewResult<TDto>.Success(resultDto, successMessage);
                }
                else
                {
                    return NewResult<TDto>.NotFound(default, notFoundMessage);
                }
            }
            catch (Exception ex)
            {
                return NewResult<TDto>.Failed(default, $"Error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles API calls that return a single entity, mapping the result to a DTO.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to map the result to.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being returned by the API call.</typeparam>
        /// <param name="apiCallTask">The task representing the API call that returns a single entity.</param>
        /// <param name="successMessage">The message to return if the API call is successful.</param>
        /// <param name="notFoundMessage">The message to return if the entity is not found.</param>
        /// <returns>A <see cref="NewResult{TDto}"/> containing the mapped DTO and a response code indicating the result of the API call.</returns>
        protected async Task<NewResult<TDto>> HandleApiCall<TDto, TEntity>(Task<NewResult<TEntity>> apiCallTask, string successMessage, string notFoundMessage)
        {
            try
            {
                var apiResult = await apiCallTask;

                if (apiResult.ResponseCode == HttpResponseCode.Success && apiResult.ResponseDetails != null)
                {
                    var resultDto = _mapper.Map<TDto>(apiResult.ResponseDetails);
                    return NewResult<TDto>.Success(resultDto, successMessage);
                }
                else
                {
                    return NewResult<TDto>.NotFound(default, notFoundMessage);
                }
            }
            catch (Exception ex)
            {
                return NewResult<TDto>.Failed(default, $"Error occurred: {ex.Message}");
            }
        }
    }
}
