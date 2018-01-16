pipeline {
     
    agent {
        label 'linux'
    }

    triggers {
        upstream(
            threshold: hudson.model.Result.SUCCESS,
        )
    }

    options {
       timeout time:2, unit:'MINUTES'
       buildDiscarder(logRotator(numToKeepStr: '20', artifactNumToKeepStr: '20'))
    }

    stages {
        stage('Test') {
            steps {
               sh 'docker-compose -f docker-compose.tests.yml run --rm tests'
            }
        }
    }
    post {
        always {
            step([
                $class: 'XUnitBuilder', testTimeMargin: '3000', thresholdMode: 1, 
                thresholds: [
                    [
                        $class: 'FailedThreshold', 
                        failureNewThreshold: '', 
                        failureThreshold: '', 
                        unstableNewThreshold: '', 
                        unstableThreshold: ''
                    ], 
                    [
                        $class: 'SkippedThreshold', 
                        failureNewThreshold: '', 
                        failureThreshold: '', 
                        unstableNewThreshold: '', 
                        unstableThreshold: ''
                    ]
                ], 
                tools: [
                    [
                        $class: 'XUnitDotNetTestType', 
                        deleteOutputFiles: true, 
                        failIfNotNew: false, 
                        pattern: 'test/Services.Tests/test-results.xml', 
                        skipNoTestFiles: false, 
                        stopProcessingIfError: false
                    ]
                ]
            ])
        }
        
        success {
            emailext body: 'All tests passing: ${BUILD_URL}', recipientProviders: [[$class: 'CulpritsRecipientProvider']], subject: '[JENKINS] ${JOB_NAME} Build #${BUILD_NUMBER} - Success', to: ''
        }

        failure {
            emailext attachLog: true, body: 'Tests are failing: ${BUILD_URL}', recipientProviders: [[$class: 'CulpritsRecipientProvider']], subject: '[JENKINS] ${JOB_NAME} Build #${BUILD_NUMBER} - Failed', to: ''
        }
    }
}