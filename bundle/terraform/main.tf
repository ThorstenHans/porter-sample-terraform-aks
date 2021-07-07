provider "azurerm" {
  features {}
}

terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "2.61.0"
    }
  }
  backend "azurerm" {
    key = "terraform.tfstate"
  }
}

variable "location" {
  type        = string
  default     = ""
  description = "Azure Region"
}

variable "custom_tags" {
  type        = map(any)
  default     = {}
  description = "Custom Tags"
}
locals {
  default_tags = {}
  tags         = merge(local.default_tags, var.custom_tags)
}

resource "azurerm_resource_group" "rg" {
  name     = "rg-thh-porter-webinar"
  location = var.location
  tags     = local.tags
}

resource "azurerm_kubernetes_cluster" "aks" {
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  name                = "aks-porter-webinar"
  dns_prefix          = "aks-porter"
  identity {
    type = "SystemAssigned"
  }
  default_node_pool {
    node_count = 1
    name       = "default"
    vm_size    = "Standard_D2_v4"
  }
  tags = local.tags
}

output "aks_name" {
    value = azurerm_kubernetes_cluster.aks.name
}

output "aks_rg_name" {
    value = azurerm_kubernetes_cluster.aks.resource_group_name
}
