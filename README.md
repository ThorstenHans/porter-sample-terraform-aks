# Porter Sample: Azure Kubernetes Service, Terraform, Helm3

This repository contains a sample application which is packaged according to [CNAB spec](https://cnab.io) using [Porter](https://porter.sh).  

The actual application is a containerized .NET API which is consumed from Docker Hub during application deployment.

Porter is responsible for:

- Establish authentication with Azure using a service principal (SP)
- Provision state management backend for [Terraform](https://terraform.io) with Azure CLI
- Provision application infrastructure (AKS) with Terraform
- Grab credentials from AKS
- Provision NGINX Ingress using [Helm](https://helm.sh)
- Provision the actual application (custom Helm chart)
