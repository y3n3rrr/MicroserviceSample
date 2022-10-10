namespace IdentityService.Services
{
    public interface IIdentityService
    {
        public Task<LoginResponseModel> SignInAsync(LoginRequestModel model);
    }
}