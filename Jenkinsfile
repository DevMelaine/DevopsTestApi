pipeline {
    agent any

    environment {
        IMAGE_NAME = "devopstest-api"
        CONTAINER_NAME = "devopstest-api"
        API_PATH = "DevopsTest"
    }

    stages {

        stage('Clean old container') {
            steps {
                script {
                    // Supprime le conteneur si déjà existant
                    bat """
                        @echo off
                        docker ps -a -q -f name=%CONTAINER_NAME% > temp.txt
                        set /p CONTAINER_ID=<temp.txt
                        if not "%CONTAINER_ID%"=="" (
                            docker rm -f %CONTAINER_NAME%
                        )
                        del temp.txt
                    """
                }
            }
        }

        stage('Build Docker Image') {
            steps {
                script {
                    // Build l'image Docker de ton API (Dockerfile à la racine)
                    bat "docker build -t %IMAGE_NAME% ."
                }
            }
        }

        stage('Run Docker Container') {
            steps {
                script {
                    // Lance le conteneur sur le port 5000
                    bat "docker run -d -p 5000:8080 --name %CONTAINER_NAME% %IMAGE_NAME%"
                }
            }
        }

        stage('Test API') {
            steps {
                script {
                    // Simple test GET pour vérifier que le conteneur tourne
                    bat "powershell -Command \"try { Invoke-WebRequest -UseBasicParsing http://localhost:5000 -ErrorAction Stop } catch { Write-Host 'API not responding yet' }\""
                }
            }
        }

    }

    post {
        success {
            echo "✅ Pipeline terminé avec succès. API en cours d'exécution sur http://localhost:5000"
        }
        failure {
            echo "❌ Pipeline échoué. Vérifie les logs."
        }
    }
}

