﻿using DEDSEC.Domain.Models;

namespace DEDSEC.Domain.Services.Authentification
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="nickname">Никнейм</param>
        /// <param name="password">Пароль</param>
        /// <param name="confirmPassword">Подтверждение пароля</param>
        /// <param name="isAdmin">Будет ли являться администратором</param>
        /// <param name="administrationCode">Код администратора</param>
        /// <returns>Аккаунт</returns>
        /// <exception cref="Exception">Неудачная попытка регистрации</exception>
        Task<Account> Register(string nickname, string password, string confirmPassword, bool isAdmin, string? administrationCode = null);


        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="nickname">Никнейм</param>
        /// <param name="password">Пароль</param>
        /// <param name="isAdmin">Является ли администратором</param>
        /// <param name="administrationCode">Код администратора</param>
        /// <returns>Аккаунт</returns>
        /// <exception cref="UserNotFoundException">Пользователь не найден</exception>
        /// <exception cref="InvalidPasswordException">Пароль не верен</exception>
        /// <exception cref="Exception">Неудачная попытка авторизации</exception>
        Task<Account> Login(string nickname, string password, bool isAdmin, string? administrationCode = null);
    }
}
