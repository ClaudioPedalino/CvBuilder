﻿global using CvBuilder.Core.CustomImplementations;
global using CvBuilder.Core.Data;
global using CvBuilder.Core.Data.Repositories;
global using CvBuilder.Core.Entities;
global using CvBuilder.Core.Extensions;
global using CvBuilder.Core.Helpers;
global using CvBuilder.Core.Identity;
global using CvBuilder.Core.Interfaces;
global using CvBuilder.Core.Interfaces.IRepositories;
global using CvBuilder.Core.Mappers;
global using CvBuilder.Core.Middlewares;
global using CvBuilder.Core.Middlewares.LoggingReqRes;
global using CvBuilder.Core.UserCases.Commands._03_AddPersonalInfo;
global using CvBuilder.Core.UserCases.Commands._07_UpdateUserPhotoUrl;
global using CvBuilder.Core.UserCases.Commands.AddAboutMeToUser;
global using CvBuilder.Core.UserCases.Commands.AddSkillToUser;
global using CvBuilder.Core.UserCases.Commands.AddWorkExperienceToUser;
global using CvBuilder.Core.UserCases.Commands.CreateUser;
global using CvBuilder.Core.UserCases.Queries.GetUsers;
global using CvBuilder.Core.Wrappers;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.ChangeTracking;
global using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.IdentityModel.Tokens;
global using Newtonsoft.Json;
global using System.IdentityModel.Tokens.Jwt;
global using System.Net;
global using System.Reflection;
global using System.Security.Claims;
global using System.Text;
global using System.Text.Json;
