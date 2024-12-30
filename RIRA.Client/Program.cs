// See https://aka.ms/new-console-template for more information
using Grpc.Core;
using Grpc.Net.Client;
using RIRA.GRPC.Protos;


try
{
    using var grpcChannel = GrpcChannel.ForAddress("http://localhost:5278");

    var client = new UserAdd.UserAddClient(grpcChannel);
    userAddRequest user = new()
    {
        FirstName = "Elham",
        LastName = "Khiabani",
        BirthDate = "1369/05/05",
        ID = 0,
        NID = "324",
        IsActive = true
    };


    userAddResponse response = client.add(user);


    Console.WriteLine("Response is::::" + response.Message);
    Console.ReadLine();
}
catch (Exception ex)
{
    var trailers = new Metadata
        {
            { "error", ex.Message }
        };
    Console.WriteLine("error::" + new RpcException(new Status(StatusCode.Unknown, "Unexpected error occurred"), trailers.GetValue("error")));
    Console.ReadLine();

}




