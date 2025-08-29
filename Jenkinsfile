pipeline {
    agent any

    tools {
        dotnet 'dotnet7'  // Nom du SDK configuré dans Jenkins
    }

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = '1'
        IMAGE_NAME = 'devops-test-api'
        IMAGE_TAG = 'latest'
    }

    stages {

        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/TON_USER/DevOpsTestApi.git'
            }
        }

        stage('Restore & Build') {
            steps {
                sh 'dotnet restore'
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test DevOpsTestApi.Tests/DevOpsTestApi.Tests.csproj --logger "trx;LogFileName=test_results.trx"'
            }
        }

        stage('Docker Build') {
            steps {
                sh "docker build -t $IMAGE_NAME:$IMAGE_TAG ."
            }
        }

        stage('Docker Run') {
            steps {
                sh "docker run -d -p 5000:5000 --name $IMAGE_NAME $IMAGE_NAME:$IMAGE_TAG"
            }
        }
    }

    post {
        always {
            echo 'Pipeline terminée.'
        }
        success {
            echo 'Pipeline exécutée avec succès !'
        }
        failure {
            echo 'Pipeline échouée.'
        }
    }
}
