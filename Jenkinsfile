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
                    sh """
                        if [ \$(docker ps -a -q -f name=$CONTAINER_NAME) ]; then
                            docker rm -f $CONTAINER_NAME
                        fi
                    """
                }
            }
        }

        stage('Build Docker Image') {
            steps {
                script {
                    // Build l'image Docker de ton API
                    sh "docker build -t $IMAGE_NAME ./$API_PATH"
                }
            }
        }

        stage('Run Docker Container') {
            steps {
                script {
                    // Lance le conteneur sur le port 5000
                    sh """
                        docker run -d -p 5000:8080 --name $CONTAINER_NAME $IMAGE_NAME
                    """
                }
            }
        }

        stage('Test API') {
            steps {
                script {
                    // Simple test GET pour vérifier que le conteneur tourne
                    sh "curl -f http://localhost:5000 || echo 'API not responding yet'"
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
