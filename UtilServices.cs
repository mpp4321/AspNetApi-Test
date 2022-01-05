using CoinpaprikaAPI;

namespace AspNetApi.Services {
public interface ICoinClient {
    Client GetClient { get; }
}

public class CoinClient : ICoinClient {
    private static Client client = new CoinpaprikaAPI.Client();
    public Client GetClient {
        get {
            return client;
        }
    }
}

}