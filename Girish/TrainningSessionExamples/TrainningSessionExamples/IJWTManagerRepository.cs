namespace TrainningSessionExamples
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Login users);
    }
}
