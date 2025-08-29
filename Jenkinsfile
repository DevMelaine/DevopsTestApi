pipeline {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/sdk:8.0'
        }
    }
    stages {
        stage('Build') {
            steps {
                sh 'dotnet restore DevopsTest/DevopsTest.csproj'
                sh 'dotnet build DevopsTest/DevopsTest.csproj -c Release'
            }
        }
        stage('Publish') {
            steps {
                sh 'dotnet publish DevopsTest/DevopsTest.csproj -c Release -o out'
            }
        }
    }
}
