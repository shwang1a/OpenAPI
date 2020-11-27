# OpenAPI

Part 1. Docker WebAPI Image
=======================================
Using OpenAPI with .NET Core <br />
https://developers.redhat.com/blog/2020/09/16/using-openapi-with-net-core/?sc_cid=7013a00000269unAAA<br />

Dockerize an ASP.NET Core application<br />
https://docs.docker.com/engine/examples/dotnetcore/<br />

webAPI testing (ps. 5001 is Swapper's port)
--------------------------
$dotnet build<br />
$docker build -t webapi1 -f Dockerfile .<br />
$docker run -d -p 5001:5001 --name webapi1 webapi1<br />
$docker inspect webapi1   #get container ip<br />

Part 2. Docker Console Image
=======================================

教學課程：將 .NET Core 應用程式<br />
https://docs.microsoft.com/zh-tw/dotnet/core/docker/build-container?tabs=windows<br />

console testing
-----------------------
$dotnet build<br />
$docker build -t client-image -f Dockerfile .<br />
$docker run --env WebApi1Url=http://{webapi1_ip_addr} client-image<br />

Part 3. Docker-compose
=========================================
1.create docker-compose.yml <br />
2.<br />
$docker-compose build<br />
$docker-compose up<br />
$docker-compose down<br />

PS. If any project source modified, need to rebuild the source as follow:<br />
    $dotnet build<br />
    $dotnet publish -c Release<br />

Part 4. (離線)Publish & Deploy Application
=========================================
1.create docker-compose-deploy.yml<br />
2.<br />
$mkdir images<br />
$docker save -o images/OpenAPI.tar shwang1a/webapi1 shwang1a/client-image<br />

other Machine
1.New app folder,then copy docker-compose-deploy.yml<br />
2.New app/images folder, then Copy OpenAPI.tar into app/images folder<br />
3.$docker load -i images/OpenAPI.tar<br />
3.$docker-compose -f docker-compose-deploy.yml up<br />

Part 5. (線上)Publish & Deploy Application
==========================================
1.create docker-compose-deploy.yml<br />
2.$docker push shwang1a/webapi1<br />
3.$docker push shwang1a/client-image<br />

other Machine
1.New app folder,then copy docker-compose-deploy.yml<br />
2.$docker-compose -f docker-compose-deploy.yml up<br />


