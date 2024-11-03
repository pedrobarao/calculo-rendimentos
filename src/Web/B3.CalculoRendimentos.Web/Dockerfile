FROM node:20 AS build
WORKDIR /app
COPY ./src/Web/B3.CalculoRendimentos.Web/package*.json ./
RUN npm install
COPY ./src/Web/B3.CalculoRendimentos.Web .
RUN npm run build --prod
RUN ls -la /app/dist/b3.calculo-rendimentos.web

FROM nginx:alpine
COPY --from=build /app/dist/b3.calculo-rendimentos.web /usr/share/nginx/html
COPY ./deploy/nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
