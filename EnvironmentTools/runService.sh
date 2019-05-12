imageName="english_statistic"
containerName="statistic_service"
networkName="english-net"

docker kill $containerName
docker rm $containerName

docker run -p 8700:8700 --name $containerName --network $networkName $imageName
