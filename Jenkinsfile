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
                    // Build l'image Docker (chemin du Dockerfile à la racine de $API_PATH)
                    sh "docker build -t $IMAGE_NAME ./$API_PATH"
                }
            }
        }

        stage('Run Docker Container') {
            steps {
                script {
                    // Lance le conteneur sur le port 5000
                    sh "docker run -d -p 5000:8080 --name $CONTAINER_NAME $IMAGE_NAME"
                }
            }
        }

        stage('Test API') {
            steps {
                script {
                    // Test simple avec curl
                    sh """
                        echo "⏳ Test de l'API..."
                        for i in {1..5}; do
                            if curl -s http://localhost:5000 > /dev/null; then
                                echo "✅ API répond correctement"
                                exit 0
                            fi
                            echo "⚠️  API pas encore dispo, nouvelle tentative..."
                            sleep 3
                        done
                        echo "❌ API ne répond pas après plusieurs tentatives"
                        exit 1
                    """
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

