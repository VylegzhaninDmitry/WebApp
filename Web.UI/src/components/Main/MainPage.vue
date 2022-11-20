<template>
    <div class="container">
        <!-- Навигационная панель -->
        <header class="nav-bar">
            <!-- Лого банка -->
            <img src="img/New_Sovcombank_logo_(updated_version).svg"
                 alt="LOGO"
                 width="200px"
                 class="logo-img" />

            <!-- Поле поиска -->
            <div class="search-form-field">
                <input type="search" class="search-field" />
                <button type="submit" class="btn-search"></button>
            </div>

            <!-- Иконки аккаунта -->
            <div class="account-icons">
                <img src="img/bell_1.svg"
                     alt="Уведомления"
                     width="42"
                     height="42"
                     class="icon-size" />
                <img src="img/email_1.svg"
                     alt="Почта"
                     width="42"
                     height="42"
                     class="icon-size" />
                <img src="img/Ellipse_9.svg"
                     alt="Плейсхолдер аккаунта"
                     width="42"
                     height="42" />
            </div>
        </header>

        <div class="wrapper">
            <!-- Основная часть -->
            <div class="main-window">
                <!-- Панель счета -->
                <!-- Мой счет -->
                <div class="superior-score-window first-window">
                    <div class="score">
                        <!-- Счет -->
                        <div class="money">
                            <p class="p-money">Мой счет</p>
                            <h2 class="h2-money">
                                5 676 231 ₽
                                <p class="percent">+10,5%</p>
                            </h2>
                        </div>
                    </div>
                    <!-- Дашборд -->
                    <div class="statistics">
                        <div class="left-icons">
                            <button class="item-left-icon">
                                <img src="img/dashboard_1.svg"
                                     alt="Дашборд"
                                     width="42"
                                     height="42"
                                     class="icon-size" />
                                <p>Дашборд</p>
                            </button>
                        </div>
                        <div class="left-icons">
                            <button class="item-left-icon">
                                <img src="img/line-chart_1.svg"
                                     alt="Аналитика"
                                     width="42"
                                     height="42"
                                     class="icon-size" />
                                <p>Аналитика</p>
                            </button>
                        </div>
                        <div class="left-icons">
                            <button class="item-left-icon">
                                <img src="img/wallet_1_1.svg"
                                     alt="Активы"
                                     width="42"
                                     height="42"
                                     class="icon-size" />
                                <p>Активы</p>
                            </button>
                        </div>
                        <div class="left-icons">
                            <button class="item-left-icon">
                                <img src="img/history_1.svg"
                                     alt="История операций"
                                     width="42"
                                     height="42"
                                     class="icon-size" />
                                <p>История операций</p>
                            </button>
                        </div>
                    </div>
                    <!-- Нижняя часть левого окна-->
                    <div class="bottom-left-icons-first">
                        <button class="item-bottom-left-icon">
                            <img src="img/user_1.svg"
                                 alt="Мой профиль"
                                 width="42"
                                 height="42"
                                 class="icon-size-bottom" />
                            <p>Мой профиль</p>
                        </button>
                    </div>

                    <div class="bottom-left-icons">
                        <button class="item-bottom-left-icon">
                            <img src="img/settings_1.svg"
                                 alt="Настройки"
                                 width="42"
                                 height="42"
                                 class="icon-size-bottom" />
                            <p>Настройки</p>
                        </button>
                    </div>

                    <div class="bottom-left-icons">
                        <button class="item-bottom-left-icon">
                            <img src="img/information_1.svg"
                                 alt="Помощь"
                                 width="42"
                                 height="42"
                                 class="icon-size-bottom" />
                            <p>Помощь</p>
                        </button>
                    </div>

                    <div class="bottom-left-icons">
                        <button class="item-bottom-left-icon">
                            <img src="img/image_1.svg"
                                 alt="Выйти из учетной записи"
                                 width="42"
                                 height="42"
                                 class="icon-size-bottom" />
                            <p>Выйти из учетной записи</p>
                        </button>
                    </div>
                </div>

                <!-- Строка валюты -->

                <div class="currency-line second-window">
                    <div class="currency-item">
                        <h2 class="currency-margin">EUR</h2>
                        <p>62,95 ₽</p>
                        <p class="positive">+7,3%</p>
                    </div>
                    <div class="currency-item">
                        <h2 class="currency-margin">USD</h2>
                        <p>60,85 ₽</p>
                        <p class="negative">-4,2%</p>
                    </div>
                    <div class="currency-item">
                        <h2 class="currency-margin">SLVR</h2>
                        <p>40,91 ₽</p>
                        <p class="negative">-4.01%</p>
                    </div>
                    <div class="add-currency">
                        <button class="currency-item-btn">
                            <img src="img/add-cur.svg"
                                 alt="Добавить"
                                 width="25" />
                        </button>
                    </div>
                </div>
                <!-- Окно выбранной валюты -->
                <div class="current-currency third-window">
                    <div>
                        <button class="current-currency-select-btn">
                            <h1 class="current-currency-select">EUR</h1>
                            <img src="img/Arrow_1.svg"
                                 alt="open"
                                 width="18px"
                                 class="arrow-img" />
                        </button>
                    </div>
                    <div>
                        <p class="positive-plot">+7,3%</p>
                    </div>

                    <div class="from-to">
                        <h2>с</h2>
                        <input type="text" class="date" />
                        <h2>по</h2>
                        <input type="text" class="date" />
                    </div>

                    <div class="plot"><h1>PLOT</h1></div>
                </div>

                <div class="buy-sell-window fourth-window">
                    <h1 class="buy-sell-title">Покупка/продажа</h1>

                    <div class="price-amount">
                        <div class="price">
                            <p class="p-price">Цена исполнения</p>
                            <input type="text"
                                   class="price-input"
                                   placeholder="₽" />
                        </div>

                        <div class="amount">
                            <p class="p-price">Количество</p>
                            <input type="text"
                                   class="price-input"
                                   placeholder="x1" />
                        </div>
                    </div>

                    <div class="avg-price-div">
                        <h2 class="avg-price">ПРИМЕРНАЯ СТОИМОСТЬ</h2>
                        <p class="p-avg-price">2157 ₽</p>
                    </div>

                    <div>
                        <input type="text" class="price-input-buy" />
                        <button class="buy-btn">Купить</button>
                        <input type="text" class="price-input-sell" />
                        <button class="sell-btn">Продать</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'MainPage'
        
    }
</script>