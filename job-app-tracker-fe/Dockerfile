# Build stage
FROM node:20-alpine as build
WORKDIR /app
COPY . .
RUN npm install && npm run build

# Serve with nginx
FROM nginx:stable-alpine
COPY --from=build /app/dist /usr/share/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf
